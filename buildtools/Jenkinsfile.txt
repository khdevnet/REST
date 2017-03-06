#!groovy
node {
	stage 'Checkout'
		checkout scm

	stage 'Build'
		bat 'nuget restore SolutionName.sln'
		bat "\"${tool 'MSBuild'}\" buildtools\watchshop.build.xml"

	stage 'Archive'
		archive 'buildartifacts/_PublishedWebsites/WatchShop.Api/**/*.*'

}