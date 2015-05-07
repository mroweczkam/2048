using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.Model
{
    class Cell
    {
        public int value { get; set; }
        public bool dirty { get; set; }
        
           
        
                
        public Cell(int value)
        {
            this.value = value;
            this.dirty = false;
         
        }

        public bool IsEmpty()
        {
            return this.value == 0;
             
        }

        public void Clear()
        {
            this.dirty = false;
            

        }
     

    }
}
