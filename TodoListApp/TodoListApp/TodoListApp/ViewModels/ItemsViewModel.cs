using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;

using TodoListApp.Models;
using TodoListApp.Views;

namespace TodoListApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ItemModel> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ItemModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as ItemModel;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }


        //public ItemsViewModel IvmUpdate()
        //{
        //    Title = "Update";
        //    Items = new ObservableCollection<ItemModel>();
        //    LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        //    MessagingCenter.Subscribe<NewItemPage, ItemModel>(this, "UpdateItem", async (obj, item) =>
        //    {
        //        var updateItem = item as ItemModel;

        //        // TODO find out a way to update the list and then
        //        // TODO return this list to the new page
        //        Items.Add(updateItem);
        //        await DataStore.UpdateItemAsync(updateItem);
                
        //    });

        //    return new ItemsViewModel();
        //}

        // TODO find a way to implement a new page that will delete
        // the users content based on the current selection. 

        public ItemsViewModel IvmDelete(ItemModel item)
        {
            Title = "Delete";
            Items = new ObservableCollection<ItemModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            // TODO change to change Message center from Subscribe to Send
            // TODO to ensure that it did not Subscribe new page
            MessagingCenter.Send(this, "DeleteItem", item);
        
            var deleteItem = item as ItemModel;
            // TODO make sure we verify that the item selected has indeed been deleted. 
            // 
            Console.WriteLine(deleteItem);
            Items.Remove(deleteItem);
            // TODO I do not thing that the tostring method is the correct way to go about this.
            // please check data store for correct delete item delegate. 
            DataStore.DeleteItemAsync(deleteItem.ToString());
            

            return new ItemsViewModel();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}