namespace addressbook
{
    class Square: Figure
    {
        private int size;
 
        public Square(int size)
        {
            this.size = size;
        }
   
  
        public int Size
        {
         get
            {
                return size;
            }
         set
            {
                size = value;
            }
        }
    }
}
