using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class Model
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Model(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void SetId(int id) 
        { 
            Id = id; 
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
