#!groovy
node {
    def buildArtifacts = "buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def buildtoolsDir = "${env.WORKSPACE}\\buildtools"
    def solutionName = 'watchshop.sln'
    def reportsDir = "${env.WORKSPACE}\\reports"
    def nunitTestReportXmlFilePath  = reportsDir + '\\TestResult.xml'
    def codeQualityDllWildCards = ["$buildArtifacts/WatchShop*.Api.dll", "$buildArtifacts/*.Domain.dll"];
    def buildresultTempleteFilePath = buildtoolsDir + '\\report\\buildresult.template.html'
    timestamps {

        stage('Notifications') {
          def templateModel = getTemplateModel(getTestReportResult(nunitTestReportXmlFilePath));
          def text = renderTemplete(buildresultTempleteFilePath, templateModel)
          echo text

          emailext body: 'test', subject: 'Test', to: 'khdevnet@gmail.com'
        }
    }
}

@NonCPS
def getTemplateModel(nunitResultMap){
    def model = ["buildResultUrl": "$BUILD_URL", "buildStatus": "Ok", 
                 "buildNumber": "$BUILD_DISPLAY_NAME", "applicationName": "$JOB_NAME"]
    for(def result : nunitResultMap ) { model.put(result.key, result.value) }
    return model
}

def renderTemplete(templateFilePath, model){
              
    def templateBody =  new File(templateFilePath).text
    def engine = new groovy.text.SimpleTemplateEngine()
    engine.createTemplate(templateBody).make(model).toString()
}

def getTestReportResult(nunitTestReportXmlFilePath){
    def testXmlRootNode = new XmlParser().parse(new File(nunitTestReportXmlFilePath))
    def resultNode = findlastNode(testXmlRootNode.children(),'test-suite')
    resultNode.attributes()
}

def findlastNode(list, nodeName){
    for(def element : list.reverse() ) { 
       if(element.name()==nodeName){
           return element
       }
    }
}

def getFiles(wildcards, rootDir=''){
    def files = []
    for(def wildcard : wildcards ) { 
        files.addAll(findFiles(glob: wildcard))
    }
    
    def names = []
    def prefix = rootDir == '' ? '' : rootDir + '\\'
    for(def file : files ) { names << prefix + file.name }
    return names
}

def cleanDir(dirPath) {
     def dir = new File(dirPath)
     if (dir.exists()) dir.deleteDir()
     if (!dir.exists()) dir.mkdirs()
}

def makeDir(dirPath) {
     def dir = new File(dirPath)
     if (!dir.exists()) dir.mkdirs()
}

def removeDir(dirPath) {
     def dir = new File(dirPath)
     if (dir.exists()) dir.deleteDir()
}
def log(message){
    println message
} 
