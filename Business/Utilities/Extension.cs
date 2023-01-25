using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities;

public static class Extension
{
    public static async Task<string> CopyFileAsync(this IFormFile file, string wwwroot, params string[] folders)
    {
        var path = wwwroot;
        var fileName = Guid.NewGuid().ToString() + file.Name;
        foreach (var folder in folders)
        {
            path = Path.Combine(path, folder);
        }
        path= Path.Combine(path, fileName); 
        using(FileStream stream=new(path,FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        path = Path.Combine(path, fileName);
        return fileName;
    }
    public static bool CheckFileSize(this IFormFile file,int kByte)
    {
        return file.Length > kByte;
    }

    }
