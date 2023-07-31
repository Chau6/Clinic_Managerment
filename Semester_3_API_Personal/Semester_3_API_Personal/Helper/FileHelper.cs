namespace Semester_3_API_Personal.Helper;

public class FileHelper
{
    // a.doc, .gif, . png, .jpg
    public static string generateFileName(string fileName)
    {
        var lastIndex = fileName.LastIndexOf('.');
        var ext = fileName.Substring(lastIndex);
        var name = Guid.NewGuid().ToString().Replace("-", "");
        return name + ext;
    }
}
