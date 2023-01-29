namespace MadeByKIRI.Value;

public static class Storage
{
	public static string BasePath;
	
	public static async Task UploadImage(int id, HttpRequest httpRequest)
	{
		var files = Directory
            .EnumerateFiles($"{BasePath}/images/goods/", "*.*", SearchOption.TopDirectoryOnly)
            .Count(s => s.Split("/").Last().Split("-").First().Equals($"{id}"));
        if (httpRequest.Form.Files.Any())
			foreach (var formFile in httpRequest.Form.Files)
			{
				var number = files + 1;
				var newPath = $"{BasePath}/images/goods/{id}-{number}{Path.GetExtension(formFile.FileName)}";
				await using var fileStream = new FileStream(newPath, FileMode.Create);
				await formFile.CopyToAsync(fileStream);
			}
	}
	public static void DeleteImage(int id, string cat, string path) =>
	  File.Delete($"{path}/img/{cat}/{id}.webp");
}
