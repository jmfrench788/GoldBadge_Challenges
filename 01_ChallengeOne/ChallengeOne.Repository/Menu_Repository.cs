using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Menu_Repository
    {
        private readonly List<Menu> _menuItems = new List<Menu>();
        private int _count;

        public List<Menu> GetAllMenuItems()
        {
            return _menuItems;
        }

        public Menu GetItemByID(int id)
        {
            foreach(var item in _menuItems)
            {
                if(item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool AddToMenu(Menu item)
        {
            if(item != null)
            {
                _count++;
                item.ID = _count;
                _menuItems.Add(item);
                return true;
            }
            return false;
        }
        
        public bool RemoveFromMenu(int id)
        {
            var item = GetItemByID(id);
            if(item != null)
            {
                _menuItems.Remove(item);
                return true;
            }
            return false;
        }
    }
