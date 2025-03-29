using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama {  get; set; }
        public int Kuantitas { get; set; }

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    public class ManajemenInventori
    {
        public LinkedList<Item> inventori = new LinkedList<Item>();

        public void TambahItem(Item item)
        {
            inventori.AddLast(item);
        }

        public bool HapusItem(string nama)
        {
            var item = inventori.FirstOrDefault(i =>  i.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase));
            return item != null && inventori.Remove(item);
        }

        public void TampilkanInventori()
        {
            foreach (var item in inventori)
            {
                Console.WriteLine($"{item.Nama}; {item.Kuantitas}");
            }
        }
    }
}
