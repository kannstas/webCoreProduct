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
			MessageResult = "��� ������ ����� ���������� ������";
		}

		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageResult = "�������� ������������ ������, ��������� ����";
			}
			var result = price * (decimal?)0.18;
			MessageResult = $"��� ������ {name} � ����� {price} ������ ��������� {result}";

			Product.Price = (decimal)price;
			Product.Name = name;


		}
		
		public void OnPostDiscont(string name, decimal? price, double discont) 
		{ 
			Product = new Product();
			var result = price * (decimal?)discont/100;

			MessageResult = $"��� ������ {name} � ����� {price} � ������� {discont} ��������� {result}";

			Product.Price = (decimal)price;
			Product.Name = name;
		}



	}
}
