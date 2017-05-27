using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace WindowsFormsApplication1
{
    class TestIContainer : IContainer
    {
        private ArrayList m_bookList;

        public TestIContainer()
        {
            m_bookList = new ArrayList();
        }


         public virtual void Add(IComponent book)
         {
             m_bookList.Add(book);
         }

        public virtual


    }
}
