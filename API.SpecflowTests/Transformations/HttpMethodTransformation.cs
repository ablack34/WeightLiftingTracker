using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.SpecflowTests.Transformations
{
    [Binding]
    public class HttpMethodTransformation
    {
        [StepArgumentTransformation]
        public HttpMethod ToHttpMethod(string method)
        {
            return new HttpMethod(method);
        }
    }
}
