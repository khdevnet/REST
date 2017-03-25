#!groovy
node {
	stage 'Checkout'
		checkout scm
	stage 'Build'
		bat "\"${tool 'nuget'}\" restore watchshop.sln"
		bat "\"${tool 'msbuild'}\" watchshop.sln /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:PackageLocation=\"${WORKSPACE}\\buildartifacts\\web.zip\" /p:Configuration=Release /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
    stage 'Tests'
		bat '''@echo off
		FOR /D /r %%G in ("*.Tests") DO (
			FOR /D %%T in ("%%G\\bin\\*") DO (
				For /F "tokens=*" %%F IN (\'dir /b /s %%T\\*.Tests.dll\') DO (
				   "\"${tool 'nunit'}\" %%F
				)))'''
	stage 'Archive'
		archive 'buildartifacts/_PublishedWebsites/WatchShop.Api/**/*.*'

}
