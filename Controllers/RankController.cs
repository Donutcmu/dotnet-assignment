using Microsoft.AspNetCore.Mvc;
using DotnetAssignment.Dtos;

namespace DotnetAssignment.Controllers
{
    [ApiController]
    [Route("api/rank")]
    public class RankController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult Rank([FromBody] RankRequest request)
        {
            
            // 1. ตรวจความยาว
            if (string.IsNullOrEmpty(request.P1) || request.P1.Length > 99)
            {
                return BadRequest("p1 length must not exceed 99 characters");
            }

            // 2. แยกด้วย comma
            var items = request.P1
                .Split(',')// แยกด้วย comma
                .Select(x => x.Trim())// ตัดช่องว่างรอบๆ
                .Where(x => !string.IsNullOrEmpty(x));// เอาค่าที่ไม่ใช่ค่าว่างออก

            // 3. เอาค่าที่ซ้ำออก
            var distinctItems = items.Distinct();

            // 4. เรียง (แบบพื้นฐาน)
            var result = distinctItems
                .OrderBy(x => char.IsDigit(x[0])) // ตัวอักษรก่อน
                .ThenBy(x => x)// ตัวเลขตามหลัง
                .Select(x => new { rank = x });// แปลงเป็น object ที่มี key ชื่อ rank
            

            return Ok(result);
            
        }
        
    }
}
