# Talegen.Imaging.Recognition
This project contains a suite of imaging recognition libraries to support a image recognition and moderation of images in applications.

## Introduction
There exists a need to abstract a wrapper around the image recognition and moderation services that are available from cloud providers so as to easily implement unit testing and configuration flexibility in applications that need to 
implement sucht technologies.

Enter this library which provides a very minimal abstraction that allows developers to easily implement an image recognition/moderation cloud service.

As an example, we have implemented a moderation library and service for AWS Rekognition image moderation.

A console test client can be found in the /tests/ folder.

**NOTE:** To avoid issues with posting test data that is against community rules, the test image dataset, located in [tests\TestAwsModeration\dataset\dataset.zip] has been password protected with password "testthese". These test images have been gathered from [pixabay.com](https://pixabay.com).

## Installation
This library is available via NuGet. To install, use the following command - 

```powershell
Install-Package Talegen.Imaging.Recognition
```

For an AWS Rekognition implementation, use the following command -

```powershell
Install-Package Talegen.Imaging.Recognition.Aws
```

## Usage

This library is used by Talegen applications to provide support for image moderation in ASP.NET Core applications. Although these libraries are open source, Talegen does not offer support on these libraries and their integrations beyond maintaining this repository.

## License
This library is licensed under the [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0) license.

## Change Log
1.0.0 - Initial release of the libraries.

## Feedback and Documentation
Feedback and Documentation can be found at [Issues](https://github.com/Talegen/Talegen.Imaging.Recognition/issues).
