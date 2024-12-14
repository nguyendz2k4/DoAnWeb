using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoAn.Migrations
{
    public partial class AddImageColumnToTblSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_About",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_About", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Config",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Config", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Contac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Contac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Feedback", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeleteBy = table.Column<int>(type: "int", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Invoice", x => x.InvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_InvoiceDetail",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_InvoiceDetail", x => new { x.InvoiceID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "tbl_Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Link = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Target = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_OderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_OderDetail", x => new { x.ID, x.ProductID });
                });

            migrationBuilder.CreateTable(
                name: "tbl_Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Satus = table.Column<bool>(type: "bit", nullable: true),
                    Delivered = table.Column<bool>(type: "bit", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CustumerID = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Post",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Decription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: true),
                    CateID = table.Column<int>(type: "int", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    BraindID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Post", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PostCategory",
                columns: table => new
                {
                    CateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PostCategory", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PostComment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PostID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PostComment", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PostTag",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PostTag", x => new { x.PostID, x.TagID });
                });

            migrationBuilder.CreateTable(
                name: "tbl_Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Image = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ListImages = table.Column<string>(type: "xml", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true, defaultValueSql: "((0))"),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    VAT = table.Column<bool>(type: "bit", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Warranty = table.Column<int>(type: "int", nullable: true),
                    Hot = table.Column<DateTime>(type: "datetime", nullable: true),
                    Decription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Detail = table.Column<string>(type: "ntext", nullable: true),
                    ViewCount = table.Column<int>(type: "int", nullable: true),
                    CateID = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    BraindID = table.Column<int>(type: "int", nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProductCategoy",
                columns: table => new
                {
                    CateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SeoTitle = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    MetaKeyWords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MetaDecription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProductCategoy", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ProductComment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ProductComment", x => x.CommentID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Slide",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Slide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Tag",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Tag", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_About");

            migrationBuilder.DropTable(
                name: "tbl_Brand");

            migrationBuilder.DropTable(
                name: "tbl_Config");

            migrationBuilder.DropTable(
                name: "tbl_Contac");

            migrationBuilder.DropTable(
                name: "tbl_Feedback");

            migrationBuilder.DropTable(
                name: "tbl_Invoice");

            migrationBuilder.DropTable(
                name: "tbl_InvoiceDetail");

            migrationBuilder.DropTable(
                name: "tbl_Menu");

            migrationBuilder.DropTable(
                name: "tbl_OderDetail");

            migrationBuilder.DropTable(
                name: "tbl_Order");

            migrationBuilder.DropTable(
                name: "tbl_Post");

            migrationBuilder.DropTable(
                name: "tbl_PostCategory");

            migrationBuilder.DropTable(
                name: "tbl_PostComment");

            migrationBuilder.DropTable(
                name: "tbl_PostTag");

            migrationBuilder.DropTable(
                name: "tbl_Product");

            migrationBuilder.DropTable(
                name: "tbl_ProductCategoy");

            migrationBuilder.DropTable(
                name: "tbl_ProductComment");

            migrationBuilder.DropTable(
                name: "tbl_Slide");

            migrationBuilder.DropTable(
                name: "tbl_Supplier");

            migrationBuilder.DropTable(
                name: "tbl_Tag");
        }
    }
}
