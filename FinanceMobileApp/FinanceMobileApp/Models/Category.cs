using System;
using System.Collections.Generic;
using System.Text;
using  FinanceMobileApp.Models;

namespace FinanceMobileApp.Models
{
    public class Category
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }

    }

	public static class CategoryData
	{
		public static IList<Category> Categories { get; private set; }

		static CategoryData()
		{
            Categories = new List<Category>();

            Categories.Add(new Category
			{
                CategoryName = "Food_and_Drink",
				ImageUrl = "Assets/Icons/catering-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Shopping",
                ImageUrl = "Assets/Icons/shopping-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Transport",
                ImageUrl = ""
            });

            Categories.Add(new Category
            {
                CategoryName = "Home",
                ImageUrl = "Assets/Icons/home-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Bills_and_Fees",
                ImageUrl = ""
            });
            Categories.Add(new Category
            {
                CategoryName = "Entertainment",
                ImageUrl = "Assets/Icons/game-icon.png"
            });

          /*  Categories.Add(new Category
            {
                CategoryName = "Car",
                ImageUrl = ""
            });
          */
            Categories.Add(new Category
            {
                CategoryName = "Travel",
                ImageUrl = "Assets/Icons/plane-icon.png"
            });
            Categories.Add(new Category
            {
                CategoryName = "HealthCare",
                ImageUrl = "Assets/Icons/hospital-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Education",
                ImageUrl = "Assets/Icons/notepad-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Groceries",
                ImageUrl = "Assets/Icons/cart-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Family_and_Personal",
                ImageUrl = "Assets/Icons/contact-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Gifts",
                ImageUrl = "Assets/Icons/gift-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Sports",
                ImageUrl = "Assets/Icons/market strategy-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Beauty",
                ImageUrl = "Assets/Icons/watch-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Work",
                ImageUrl = "Assets/Icons/market analysis-icon.png"
            });

            Categories.Add(new Category
            {
                CategoryName = "Other",
                ImageUrl = "Assets/Icons/find-icon.png"
            });
        }
	}
}