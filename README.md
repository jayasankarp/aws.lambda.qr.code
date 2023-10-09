# .NET 6 AWS Lambda Deployment with Pulumi

This repository contains a simple example of how to use [Pulumi](https://www.pulumi.com/) to deploy an AWS Lambda function created using the [.NET 6 framework](https://dotnet.microsoft.com/).

## Prerequisites

Before you begin, make sure you have the following prerequisites installed:

- [Pulumi CLI](https://www.pulumi.com/docs/get-started/install/)
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Getting Started

Follow these steps to deploy the AWS Lambda function using Pulumi:

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/jayasankarp/aws.lambda.qr.code.git
   cd aws.lambda.qr.code
   ```

2. Initialize a new Pulumi stack:

   ```bash
   pulumi stack init aws.lambda.qr.code
   ```

3. Configure your AWS credentials using the Pulumi CLI:

   ```bash
   pulumi config set aws:region us-east-1  # Replace with your desired AWS region
   pulumi config set aws:profile your-aws-profile-name  # If using named profiles
   ```

4. Build and publish the .NET 6 Lambda function:

   ```bash
   dotnet publish -c Release
   ```

5. Deploy the AWS Lambda function using Pulumi:

   ```bash
   pulumi up
   ```

6. After the deployment is complete, Pulumi will provide you with the AWS Lambda function's endpoint and other relevant information. You can access your Lambda function in the AWS Management Console.

## Cleanup

To clean up and destroy the AWS resources created by Pulumi, run:

```bash
pulumi destroy
```

## Additional Resources

- [Pulumi Documentation](https://www.pulumi.com/docs/)
- [.NET 6 Documentation](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6)
- [AWS Lambda Documentation](https://aws.amazon.com/lambda/)

Happy coding! 🚀