﻿using System.Data.Entity;
using MvcTraining.Web.Areas.Admin.Models;
using MvcTraining.Web.Areas.Online.Models;

namespace MvcTraining.Web.Models
{
	public class MvcTrainingContext : DbContext
	{
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MvcTraining.Web.Models.MvcTrainingContext>());

        public MvcTrainingContext() : base("name=MvcTrainingContext")
        {
        }

		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
	}
}
