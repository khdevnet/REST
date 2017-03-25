#!groovy
node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat "\"${tool 'nuget'}\" restore watchshop.sln"
		bat "\"${tool 'msbuild'}\" watchshop.sln /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:PackageLocation=\"${WORKSPACE}\\buildartifacts\\web.zip\" /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
    stage 'Tests'
	    bat "\"${tool 'nunit'}\" \"${WORKSPACE}\\src\\WatchShop.Tests\\bin\\Release\\watchshop.tests.dll\""
	stage 'Archive'
		archive 'buildartifacts/_PublishedWebsites/WatchShop.Api/**/*.*'

}
