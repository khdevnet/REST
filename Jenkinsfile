#!groovy
node {
    def buildArtifacts = "buildartifacts"
    def buildArtifactsDir = "${env.WORKSPACE}\\$buildArtifacts"
    def buildtoolsDir = "${env.WORKSPACE}\\buildtools"
    def solutionName = 'watchshop.sln'
    def reportsDir = "${env.WORKSPACE}\\reports"
    def nunitTestReportXmlFilePath  = reportsDir + '\\TestResult.xml'
    def buildresultTemplateFilePath = buildtoolsDir + '\\report\\buildresult.template.html'
    def codeQualityDllWildCards = ["$buildArtifacts/*.Domain.dll"];
    
    timestamps {
        stage('Checkout') {
            //cleanDir(buildArtifactsDir)
            //cleanDir(reportsDir)
            git 'https://github.com/khdevnet/REST.git'
        }
        def buildStatus = BuildStatus.Ok
        try {

            //stage('Build') {
                //bat "\"${tool 'nuget'}\" restore $solutionName"
                //bat "\"${tool 'msbuild'}\" $solutionName  /p:DeployOnBuild=true;DeployTarget=Package /p:Configuration=Release;OutputPath=\"$buildArtifactsDir\" /p:Platform=\"Any CPU\" /p:ProductVersion=1.0.0.${env.BUILD_NUMBER}"
            //}

            //stage('Tests') {
                //def testFilesName = getFiles(["$buildArtifacts/*.Tests.dll"], buildArtifactsDir).join(' ')
                //bat """${tool 'nunit'} $testFilesName --work=$reportsDir"""          
            //}

            stage('CodeQuality') {
              def codeQualityDllNames = getFiles(codeQualityDllWildCards, buildArtifactsDir)
              for(def fileName : codeQualityDllNames ) { 
                 try{
                  bat """${tool 'fxcop'} /f:$fileName /o:$reportsDir\\${new File(fileName).name}.fxcop.xml"""
                 } catch(Exception ex) {
                    echo ex.getMessage()
                    buildStatus = BuildStatus.Warning
                 }
              }
                println '========================================='
                for(def fxCopReportFilePath : getFiles(["reports/*.fxcop.xml"], reportsDir) ) {
                    getFxCopReportStatistic("${reportsDir}\\${new File(fxCopReportFilePath).name}") 
               }
            }

     //       stage('Archive') {
     //           archiveArtifacts artifacts: 'buildartifacts/_PublishedWebsites/WatchShop.Api_Package/**/*.*', onlyIfSuccessful: true
      //      }
        } catch (ex) {
            buildStatus = BuildStatus.Error;
            echo ex
            exit 1
        } finally {
            echo '===FINALY==='
            stage('Notifications') {
              def subject = "Build $buildStatus - $JOB_NAME ($BUILD_DISPLAY_NAME)"
              def emailBody = renderTemplete(
                  buildresultTemplateFilePath, 
                  getTemplateModel(getTestReportResult(nunitTestReportXmlFilePath), buildStatus))
                
              //emailext body: emailBody, subject: subject, to: 'khdevnet@gmail.com'
            }
       }
    }
}
// parse fx cop
def getFxCopReportStatistic(fxCopReportFilePath){
   def errorsCount = 0
   def warningsCount = 0
   def fxCopRootNode = new XmlParser().parse(new File(fxCopReportFilePath))
   def namespacesNode = getFirstNodeByName(fxCopRootNode.children(), 'Namespaces')
   def namespaceNodes = getAllNodesByName(namespacesNode.children(), 'Namespace');
   
   for(def node : namespaceNodes ) {
       def messagesNode = getFirstNodeByName(node.children(), 'Messages')
       def messageNodes = getAllNodesByName(messagesNode.children(), 'Message')
       for(def messageNode : messageNodes ) {
           def issueNode = getFirstNodeByName(messageNode.children(), 'Issue')
           def levelAttribute = issueNode.attribute('Level')
           if(levelAttribute == 'Warning'){
               warningsCount++
           }
           if(levelAttribute == 'Error'){
               errorsCount++
           }
       }
    }
    println warningsCount
    println errorsCount
   // return new FxCopStatistic(errorsCount, warningsCount)
}

def getFirstNodeByName(nodes ,nodeName){
        for(def node : nodes ) {
            if(node.name() == nodeName){
                return node
            }
        }
    }
    
def getAllNodesByName(nodes ,nodeName){
        def list = []
        for(def node : nodes ) {
            if(node.name() == nodeName){
               list << node
            }
        }
        return list
    }
def getTemplateModel(nunitResultMap, buildStatus){
    def model = ["buildResultUrl": "$BUILD_URL", "buildStatus": buildStatus, 
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

class FxCopStatistic {
      FxCopStatistic(errorsCount, warningsCount){
        ErrorsCount = errorsCount
        WarningsCount = warningsCount
      }
      int ErrorsCount
      int WarningsCount
}

     class BuildStatus {
           static String Ok = 'Ok'
           static String Error = 'Error'
           static String Warning = 'Warning'
     }
