using System.Collections.Generic;

namespace BlazorApp.Models
{
    public interface ITechRepository
    {
        void AddTech(Tech model); // 입력
        List<Tech> GetTechs(); // 출력
    }
}
