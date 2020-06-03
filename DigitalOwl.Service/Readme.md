---
tags : Avalanche , services
---

## Template services
```c#=
class ITemplateServices{
    Task<ResponseResultDto<Dto>> CreateAsync(Dto dto, int userId);
    
    Task<ResponseResultDto<IEnumerable<Dto>>> GetAll();
    Task<ResponseResultDto<Dto>> GetById(int id);

    /*
     *  if failed return ResponseDto.Failed
     *  else ResponseResultDto<Dto>
     */
    Task<ResponseDto> UpdateAsync(Dto dto, int userId);

    Task<ResponseDto> Delete(int id);

}
```