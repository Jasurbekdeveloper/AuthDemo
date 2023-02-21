using AuthDemo.Aplication.PagenationModel;
using AuthDemo.Domain.Exceptions;

namespace AuthDemo.Aplication.QueryExtention;
public static class ValidateQuery
{
    public static void VerifyQueryParametr(QueryParam queryParameter)
    {
        if (queryParameter.Page <= 0 || queryParameter.Size <= 0)
        {
            throw new ValidationQuery("Page yoki size qiymati 0 dan kichik bo'lmasligi kerak");
        }
        if (queryParameter.Size > 100)
        {
            throw new ValidationQuery("Size qiymati 100 dan oshmasligi kerak.");
        }
    }
}

