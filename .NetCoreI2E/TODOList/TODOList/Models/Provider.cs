using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.Models
{
    public class Provider
    {
        static List<Lists> lists = new List<Lists>();
        private static int counter = 0;
        
        public List<Lists> GetLists()
        {
            return lists;
        }

        public void CreateList(string listName)
        {
            counter = lists.Count + 1;
            lists.Add(new Lists {Id = counter, ListName = listName, Items = new List<ListItem>() });
        }

        public Lists GetListsById(int listId)
        {
            return lists.FirstOrDefault(x => x.Id == listId);
        }

        public int GetListCount()
        {
            return lists.Count;
        }

        public void AddItemToList(int listId, string ItemName)
        {
            Lists list = GetListsById(listId);
            int itemCount = list.Items.Count + 1;
            list.Items.Add(new ListItem { Id = itemCount, text = ItemName, checkedFlag = false });
        }

        public void UpdateListItemFlag(int listId, int itemId)
        {
            Lists lists = GetListsById(listId);
            ListItem item = lists.Items.FirstOrDefault(x => x.Id == itemId);
            item.checkedFlag = !item.checkedFlag;
        }
    }
}
