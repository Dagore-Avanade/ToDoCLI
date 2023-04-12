using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCLI
{
    class ToDoRepository
    {
        int nextId = 4;
        ToDoItem[] toDoItemsArray =
        {
            new ToDoItem{Id = 1, Finished = false, Description = "Terminar este programa"},
            new ToDoItem{Id = 2, Finished = false, Description = "Rellenar ficha de esta semana"},
            new ToDoItem{Id = 3, Finished = true, Description = "Ver curso sobre colecciones"}
        };

        public string GetAll()
        {
            Array.Sort(toDoItemsArray);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (ToDoItem item in toDoItemsArray)
            {
                if (item != null)
                    stringBuilder.AppendLine(item.ToString());
            }
            return stringBuilder.ToString();
        }
        public void Add(string description)
        {
            var newToDoItem = new ToDoItem()
            {
                Id = nextId++,
                Description = description,
                Finished = false
            };
            int index = Array.FindIndex(toDoItemsArray, todo => todo is null);
            if (index != -1)
            {
                toDoItemsArray[index] = newToDoItem;
            }
            else
            {
                Array.Resize(ref toDoItemsArray, toDoItemsArray.Length * 2);
                toDoItemsArray[toDoItemsArray.Length - 1] = newToDoItem;
            }
        }
        public bool DeleteById(int id)
        {
            int index = Array.FindIndex(toDoItemsArray, todo => todo?.Id == id);
            if (index == -1)
            {
                return false;
            }

            toDoItemsArray[index] = null;
            return true;
        }
        public bool ToggleById(int id)
        {
            int index = Array.FindIndex(toDoItemsArray, todo => todo?.Id == id);
            if (index == -1)
            {
                return false;
            }

            toDoItemsArray[index].Finished = !toDoItemsArray[index].Finished;
            return true;
        }
    }
}
