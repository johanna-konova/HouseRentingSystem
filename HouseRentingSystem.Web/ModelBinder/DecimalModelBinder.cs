using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace HouseRentingSystem.Web.ModelBinder
{
	public class DecimalModelBinder : IModelBinder
	{
		public Task BindModelAsync(ModelBindingContext bindingContext)
		{
			var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None
				&& !string.IsNullOrEmpty(valueResult.FirstValue))
            {
				decimal result = 0.00M;
				bool success = false;

				try
				{
					string valueAsString = valueResult.FirstValue;
					valueAsString = valueAsString.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
					valueAsString = valueAsString.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

					result = Convert.ToDecimal(valueAsString);
					success = true;
				}
				catch (FormatException fe)
				{
					bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
				}

                if (success)
                {
					bindingContext.Result = ModelBindingResult.Success(result);
				}
            }

			return Task.CompletedTask;
        }
	}
}
