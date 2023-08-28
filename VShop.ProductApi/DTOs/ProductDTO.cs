using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs;

public class ProductDTO
{
  public int ProductId { get; set; }

  [Required(ErrorMessage = "Name is required")]
  [MinLength(3)]
  [MaxLength(100)]
  public string? Name { get; set; }

  [Required(ErrorMessage = "Description is required")]
  [MinLength(3)]
  [MaxLength(250)]
  public string? Description { get; set; }

  [Required(ErrorMessage = "Price is required")]
  public decimal Price { get; set; }

  [Required(ErrorMessage = "Stock is required")]
  [Range(1, 9999)]
  public long Stock { get; set; }
  public string? ImageURL { get; set; }

  [JsonIgnore]
  public Category? Category { get; set; }
  public int CategoryId { get; set; }
}
