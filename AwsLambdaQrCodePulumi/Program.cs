using Pulumi;
using System.Threading.Tasks;
using Pulumi.Aws.Iam;
using Pulumi.Aws.Lambda;

class Program
{
   static Task<int> Main() => Deployment.RunAsync<LambdaStack>();
}

class LambdaStack : Stack
{
   public LambdaStack()
   {
      var lambda = new Function("awsLambdaQrCodeGenerator", new FunctionArgs
      {
         Runtime = "dotnet6",
         Code = new FileArchive("../AwsQrCodeGenerator/bin/Release/net6.0/publish"),
         Handler = "AwsLambdaQrCodeGenerator::AwsLambdaQrCodeGenerator.Function::FunctionHandler",
         Role = CreateLambdaRole().Arn
      });

      this.Lambda = lambda.Arn;
   }

   [Output] public Output<string> Lambda { get; set; }

   private static Role CreateLambdaRole()
   {
      var lambdaRole = new Role("lambdaRole", new RoleArgs
      {
         AssumeRolePolicy =
            @"{
                ""Version"": ""2012-10-17"",
                ""Statement"": [
                    {
                        ""Action"": ""sts:AssumeRole"",
                        ""Principal"": {
                            ""Service"": ""lambda.amazonaws.com""
                        },
                        ""Effect"": ""Allow"",
                        ""Sid"": """"
                    }
                ]
            }"
      });

      var logPolicy = new RolePolicy("lambdaLogPolicy", new RolePolicyArgs
      {
         Role = lambdaRole.Id,
         Policy =
            @"{
                ""Version"": ""2012-10-17"",
                ""Statement"": [{
                    ""Effect"": ""Allow"",
                    ""Action"": [
                        ""logs:CreateLogGroup"",
                        ""logs:CreateLogStream"",
                        ""logs:PutLogEvents""
                    ],
                    ""Resource"": ""arn:aws:logs:*:*:*""
                }]
            }"
      });

      return lambdaRole;
   }
}