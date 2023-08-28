using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
/// <inheritdoc />
public partial class SeedProducts : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder mb)
  {
    mb.Sql("INSERT INTO public.\"Products\"(\"Name\", \"Description\", \"Price\", \"Stock\", \"ImageURL\", \"CategoryId\")" +
    " VALUES('Lapis', 'Lapis ponta fina', 2.00, 10, 'lapis.jpg', 1) ");

    mb.Sql("INSERT INTO public.\"Products\"(\"Name\", \"Description\", \"Price\", \"Stock\", \"ImageURL\", \"CategoryId\")" +
    " VALUES('Caneta', 'Caneta Azul', 3.00, 10, 'canetaAzul.jpg', 1) ");

    mb.Sql("INSERT INTO public.\"Products\"(\"Name\", \"Description\", \"Price\", \"Stock\", \"ImageURL\", \"CategoryId\")" +
    " VALUES('Relogio', 'Relogiozão', 359.99, 10, 'relogio.jpg', 2) ");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder mb)
  {
    mb.Sql("DELETE FROM public.\"Products\"");
  }
}
}
