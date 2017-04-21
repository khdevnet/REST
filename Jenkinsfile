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
          def model = ["buildResultUrl": "$BUILD_URL", "buildStatus": "Ok", 
                       "buildNumber": "$BUILD_DISPLAY_NAME", "applicationName": "$JOB_NAME", 
                       "total":"1", "passed":"1", "failed":"1", "warnings":"1", "inconclusive":"1", "skipped":"1"]
          def text = renderTemplete(buildresultTempleteFilePath, model)
          println text  
          emailext body: "$text", subject: 'Test', to: 'khdevnet@gmail.com'
        }
    }
}
def text = 'Dear "$firstname $lastname",\nSo nice to meet you in <% print city %>.\nSee you in ${month},\n${signed}'
def binding = ["firstname":"Sam", "lastname":"Pullara", "city":"San Francisco", "month":"December", "signed":"Groovy-Dev"]

def renderTemplete(templateFilePath, model){
    def templateBody =  new File(templateFilePath).text
    def engine = new groovy.text.SimpleTemplateEngine()
    String body = engine.createTemplate(templateBody).make(model).toString()
    return body
}

def writeTestRunResultToReport(nunitTestReportXmlFilePath,reportFilePath){
    def testXmlRootNode = new XmlParser().parse(new File(nunitTestReportXmlFilePath))
    def resultNode = findlastNode(testXmlRootNode.children(),'test-suite')
    def testReportFile = new File(reportFilePath)
    def resultNodeAttributes =  resultNode.attributes()
    testReportFile << 'total:' + resultNodeAttributes.get("total")
    testReportFile << ' passed:' + resultNodeAttributes.get("passed")
    testReportFile << ' failed:' + resultNodeAttributes.get("failed")
    testReportFile << ' warnings:' + resultNodeAttributes.get("warnings")
    testReportFile << ' inconclusive:' + resultNodeAttributes.get("inconclusive")
    testReportFile << ' skipped:' + resultNodeAttributes.get("skipped")
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
