using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace BaoBinh_241230664.Models
{
    [ModelMetadataType(typeof(SachMetadata))]
    public partial class Sach { }

    public class SachMetadata
    {
        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string TenSach { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(50, 1000, ErrorMessage = "Giá phải nằm trong khoảng từ 50 đến 1000")]
        public decimal? Gia { get; set; }

        [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$",
            ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
        public string? Anh { get; set; }
    }
}