using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TrackerAPI.Test
{
    public class LiftingStatEntityClass
    {
        [Fact]
        public void LiftingStatEntityClass_ConvertToDateOnly_ReturnsDateOnly()
        {
            //Arrange
            CultureInfo provider = CultureInfo.InvariantCulture;
            var format = "d";

            //Act
            DateTime dateOnly = DateTime.Today;
            string formatDateOnly = dateOnly.ToString(format);

            //Assert
            Assert.IsType<String>(formatDateOnly);
            Assert.Equal(DateTime.Today.Date.ToString("d"), formatDateOnly);
        }
    }
}
