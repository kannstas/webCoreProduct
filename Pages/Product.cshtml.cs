using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebCoreProduct.Models;

namespace WebCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
		public Product Product { get; set; }
		public string? MessageResult { get; private set; }

		public void OnGet()
		{
			MessageResult = "Для товара нужно определить скидку";
		}

		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageResult = "Переданы некорректные данные, повторите ввод";
			}
			var result = price * (decimal?)0.18;
			MessageResult = $"Для товара {name} с ценой {price} скидка получится {result}";

			Product.Price = (decimal)price;
			Product.Name = name;


		}
		
		public void OnPostDiscont(string name, decimal? price, double discont) 
		{ 
			Product = new Product();
			var result = price * (decimal?)discont/100;

			MessageResult = $"Для товара {name} с ценой {price} и скидкой {discont} получится {result}";

			Product.Price = (decimal)price;
			Product.Name = name;
		}



	}
}
