using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoAn.Models
{
	public partial class APSWeb1Context : IdentityDbContext<AppUserModel>
	{
		public APSWeb1Context()
		{
		}

		public APSWeb1Context(DbContextOptions<APSWeb1Context> options)
			: base(options)
		{
		}


		public virtual DbSet<TblAbout> TblAbouts { get; set; } = null!;
		public virtual DbSet<TblBrand> TblBrands { get; set; } = null!;
		public virtual DbSet<TblConfig> TblConfigs { get; set; } = null!;
		public virtual DbSet<TblContac> TblContacs { get; set; } = null!;
		public virtual DbSet<TblFeedback> TblFeedbacks { get; set; } = null!;
		public virtual DbSet<TblInvoice> TblInvoices { get; set; } = null!;
		public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; } = null!;
		public virtual DbSet<TblMenu> TblMenus { get; set; } = null!;
		public virtual DbSet<TblOderDetail> TblOderDetails { get; set; } = null!;
		public virtual DbSet<TblOrder> TblOrders { get; set; } = null!;
		public virtual DbSet<TblPost> TblPosts { get; set; } = null!;
		public virtual DbSet<TblPostCategory> TblPostCategories { get; set; } = null!;
		public virtual DbSet<TblPostComment> TblPostComments { get; set; } = null!;
		public virtual DbSet<TblPostTag> TblPostTags { get; set; } = null!;
		public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
		public virtual DbSet<TblProductCategoy> TblProductCategoys { get; set; } = null!;
		public virtual DbSet<TblProductComment> TblProductComments { get; set; } = null!;
		public virtual DbSet<TblSlide> TblSlides { get; set; } = null!;
		public virtual DbSet<TblSupplier> TblSuppliers { get; set; } = null!;
		public virtual DbSet<TblTag> TblTags { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); // Thêm dòng này

			modelBuilder.Entity<TblAbout>(entity =>
			{
				entity.ToTable("tbl_About");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Description).HasMaxLength(50);

				entity.Property(e => e.Detail).HasColumnType("ntext");

				entity.Property(e => e.MetaDecription).HasMaxLength(250);

				entity.Property(e => e.MetaKeyWords).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(50);

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});
			modelBuilder.Entity<TblBrand>(entity =>
			{
				entity.ToTable("tbl_Brand");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Name).HasMaxLength(250);
			});

			modelBuilder.Entity<TblConfig>(entity =>
			{
				entity.ToTable("tbl_Config");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Name).HasMaxLength(50);

				entity.Property(e => e.Type).HasMaxLength(50);

				entity.Property(e => e.Value).HasMaxLength(50);
			});

			modelBuilder.Entity<TblContac>(entity =>
			{
				entity.ToTable("tbl_Contac");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Detail).HasColumnType("ntext");

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(50);
			});

			modelBuilder.Entity<TblFeedback>(entity =>
			{
				entity.ToTable("tbl_Feedback");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address).HasMaxLength(250);

				entity.Property(e => e.Detail).HasMaxLength(500);

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(150);

				entity.Property(e => e.Phone).HasMaxLength(50);
			});

			modelBuilder.Entity<TblInvoice>(entity =>
			{
				entity.HasKey(e => e.InvoiceId);

				entity.ToTable("tbl_Invoice");

				entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.DeleteDate).HasColumnType("datetime");

				entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblInvoiceDetail>(entity =>
			{
				entity.HasKey(e => new { e.InvoiceId, e.ProductId });

				entity.ToTable("tbl_InvoiceDetail");

				entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

				entity.Property(e => e.ProductId).HasColumnName("ProductID");

				entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

				entity.Property(e => e.ProductName).HasMaxLength(250);
			});

			modelBuilder.Entity<TblMenu>(entity =>
			{
				entity.ToTable("tbl_Menu");

				entity.Property(e => e.Id)
					.ValueGeneratedNever()
					.HasColumnName("ID");

				entity.Property(e => e.Description).HasMaxLength(500);

				entity.Property(e => e.Link).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.Target).HasMaxLength(50);
			});

			modelBuilder.Entity<TblOderDetail>(entity =>
			{
				entity.HasKey(e => new { e.Id, e.ProductId });

				entity.ToTable("tbl_OderDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.ProductId).HasColumnName("ProductID");

				entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

				entity.Property(e => e.ProductName).HasMaxLength(50);
			});

			modelBuilder.Entity<TblOrder>(entity =>
			{
				entity.HasKey(e => e.OrderId);

				entity.ToTable("tbl_Order");

				entity.Property(e => e.OrderId).HasColumnName("OrderID");

				entity.Property(e => e.CustumerId).HasColumnName("CustumerID");

				entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

				entity.Property(e => e.OrderDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblPost>(entity =>
			{
				entity.HasKey(e => e.PostId);

				entity.ToTable("tbl_Post");

				entity.Property(e => e.PostId)
					.ValueGeneratedNever()
					.HasColumnName("PostID");

				entity.Property(e => e.BraindId).HasColumnName("BraindID");

				entity.Property(e => e.CateId).HasColumnName("CateID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Decription).HasMaxLength(500);

				entity.Property(e => e.Detail).HasColumnType("ntext");

				entity.Property(e => e.Image).HasMaxLength(250);

				entity.Property(e => e.MetaDecription).HasMaxLength(250);

				entity.Property(e => e.MetaKeyWords).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.SeoTitle).HasMaxLength(250);

				entity.Property(e => e.Status).HasDefaultValueSql("((1))");

				entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

				entity.Property(e => e.Tags).HasMaxLength(250);

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblPostCategory>(entity =>
			{
				entity.HasKey(e => e.CateId);

				entity.ToTable("tbl_PostCategory");

				entity.Property(e => e.CateId).HasColumnName("CateID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.MetaDecription).HasMaxLength(250);

				entity.Property(e => e.MetaKeyWords).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.ParentId).HasColumnName("ParentID");

				entity.Property(e => e.SeoTitle).HasMaxLength(250);

				entity.Property(e => e.Status).HasDefaultValueSql("((1))");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblPostComment>(entity =>
			{
				entity.HasKey(e => e.CommentId);

				entity.ToTable("tbl_PostComment");

				entity.Property(e => e.CommentId).HasColumnName("CommentID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Detail).HasMaxLength(500);

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(150);

				entity.Property(e => e.PostId).HasColumnName("PostID");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblPostTag>(entity =>
			{
				entity.HasKey(e => new { e.PostId, e.TagId });

				entity.ToTable("tbl_PostTag");

				entity.Property(e => e.PostId).HasColumnName("PostID");

				entity.Property(e => e.TagId).HasColumnName("TagID");
			});

			modelBuilder.Entity<TblProduct>(entity =>
			{
				entity.HasKey(e => e.ProductId);

				entity.ToTable("tbl_Product");

				entity.Property(e => e.ProductId).HasColumnName("ProductID");

				entity.Property(e => e.BraindId).HasColumnName("BraindID");

				entity.Property(e => e.CateId).HasColumnName("CateID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Decription).HasMaxLength(500);

				entity.Property(e => e.Detail).HasColumnType("ntext");

				entity.Property(e => e.Hot).HasColumnType("datetime");

				entity.Property(e => e.Image).HasMaxLength(250);

				entity.Property(e => e.ListImages).HasColumnType("xml");

				entity.Property(e => e.MetaDecription).HasMaxLength(250);

				entity.Property(e => e.MetaKeyWords).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.Price)
					.HasColumnType("decimal(18, 0)")
					.HasDefaultValueSql("((0))");

				entity.Property(e => e.PromotionPrice).HasColumnType("decimal(18, 0)");

				entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

				entity.Property(e => e.SeoTitle).HasMaxLength(250);

				entity.Property(e => e.Status).HasDefaultValueSql("((1))");

				entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");

				entity.Property(e => e.Vat).HasColumnName("VAT");
			});

			modelBuilder.Entity<TblProductCategoy>(entity =>
			{
				entity.HasKey(e => e.CateId);

				entity.ToTable("tbl_ProductCategoy");

				entity.Property(e => e.CateId).HasColumnName("CateID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.MetaDecription).HasMaxLength(250);

				entity.Property(e => e.MetaKeyWords).HasMaxLength(250);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.ParentId).HasColumnName("ParentID");

				entity.Property(e => e.SeoTitle).HasMaxLength(250);

				entity.Property(e => e.Status).HasDefaultValueSql("((1))");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblProductComment>(entity =>
			{
				entity.HasKey(e => e.CommentId);

				entity.ToTable("tbl_ProductComment");

				entity.Property(e => e.CommentId).HasColumnName("CommentID");

				entity.Property(e => e.CreateDate)
					.HasColumnType("datetime")
					.HasDefaultValueSql("(getdate())");

				entity.Property(e => e.Detail).HasMaxLength(500);

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(150);

				entity.Property(e => e.ProductId).HasColumnName("ProductID");

				entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			});

			modelBuilder.Entity<TblSlide>(entity =>
			{
				entity.ToTable("tbl_Slide");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Image).HasMaxLength(50);

				entity.Property(e => e.Link).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(50);
			});

			modelBuilder.Entity<TblSupplier>(entity =>
			{
				entity.ToTable("tbl_Supplier");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Address).HasMaxLength(50);

				entity.Property(e => e.Descriptions).HasColumnType("ntext");

				entity.Property(e => e.Email).HasMaxLength(50);

				entity.Property(e => e.Image).HasMaxLength(50);

				entity.Property(e => e.Name).HasMaxLength(250);

				entity.Property(e => e.Phone).HasMaxLength(50);
			});

			modelBuilder.Entity<TblTag>(entity =>
			{
				entity.ToTable("tbl_Tag");

				entity.Property(e => e.Id)
					.HasMaxLength(50)
					.HasColumnName("ID");

				entity.Property(e => e.Name).HasMaxLength(500);
			});
			OnModelCreatingPartial(modelBuilder);
		}
		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}