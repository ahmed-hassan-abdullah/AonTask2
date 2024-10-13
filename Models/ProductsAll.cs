using System.ComponentModel.DataAnnotations;

namespace AonFreelancing.Models
{
    //تم اضافة بعض العناصر الاضافية مثل اسم المنتج ,السعر  ,الفئة ,وصف المنتج 
    public class ProductsAll
    {

        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public string Category { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        

    }


}
