namespace Profilum.UserService.Common.BaseModels
{
	// ReSharper disable once ClassNeverInstantiated.Global
	public class AppResponse
	{
		public class Response
		{
			public bool IsCriticalCode =>
				!(ResultCode == ResponseCodes.SUCCESS || ResultCode == ResponseCodes.NOT_FOUND_RECORDS);

			public bool IsSuccess => ResultCode == ResponseCodes.SUCCESS;
			
			public string Code => ResultCode.ToString();

			public ResponseCodes ResultCode { get; set; } = ResponseCodes.SUCCESS;

			public List<CustomError> Errors { get; set; }

			public string LastResultMessage => Errors?.LastOrDefault()?.ResultMessage;
		}

		public class Response<T> : Response
		{
			public Response()
			{}
			
	        public Response(T data) => Data = data;

	        public T Data { get; set; }
        }

		public class ErrorResponse : Response
		{
			public ErrorResponse(string errorMessage, ResponseCodes responseCode = ResponseCodes.TECHNICAL_ERROR)
			{
				ResultCode = responseCode;

				Errors ??= new List<CustomError>();

				Errors.Add(new CustomError
				{
					ResponseCode = responseCode,
					ResultMessage = errorMessage
				});
			}

			public ErrorResponse(CustomError error)
			{
				ResultCode = error.ResponseCode;
				
				Errors ??= new List<CustomError>();
				Errors.Add(error);
			}

			public ErrorResponse(IEnumerable<CustomError> errors)
			{
				ResultCode = ResponseCodes.FAILURE;
				
				Errors ??= new List<CustomError>();
				Errors.AddRange(errors);
			}
		}

		public class ErrorResponse<T> : Response<T>
		{
			public ErrorResponse(string errorMessage, ResponseCodes responseCode = ResponseCodes.TECHNICAL_ERROR)
			{
				ResultCode = responseCode;
				
				Errors ??= new List<CustomError>();

				Errors.Add(new CustomError
				{
					ResponseCode = responseCode,
					ResultMessage = errorMessage
				});
			}

			public ErrorResponse(IEnumerable<CustomError> errors)
			{
				var customErrors = errors.ToList();
				ResultCode = customErrors.LastOrDefault()?.ResponseCode ?? ResponseCodes.FAILURE;
				
				Errors ??= new List<CustomError>();

				Errors.AddRange(customErrors);
			}
		}
	}
}