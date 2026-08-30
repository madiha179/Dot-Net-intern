using System;
using System.Collections.Generic;
using System.Text;

namespace task2
{
    internal class Book
    {
        private int id;
      private  string title;
       private string autherName;
       private bool isAvailable =true;
        public string getBookName()
        {
            return title;
        }
        public string getAutherName()
        {
            return autherName;
        }
        public int getId()
        {
            return id;
        }
        public bool getisAvailable()
        {
            return isAvailable;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setTitle(string title)
        {
            this.title = title;
        }
        public void setAutherName(string autherName)
        {
            this.autherName = autherName;
        }
        public void setisAvailable(bool isAvailable)
        {
            this.isAvailable = isAvailable;
        }
    }
}
