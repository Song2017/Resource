* To run this jmeter script, you need do the followings on your test machines, assuming that your test machines are running Windows Server 2012 R2.
1. Prepare your test machine
    * Disable IE Enhanced Security Configuration on Server Manager > Local Server
    * Turn off firewall
    * Change time zone on your test machines to your local
2. Install JRE
    * Download JRE from www.java.com and install. // Recommend that you install the same version on all of your machines
3. Install and configure JMeter
    * Download jmeter binaries (e.g. apache-jmeter-2.13.zip) from http://jmeter.apache.org/download_jmeter.cgi
    * Extract jmeter to c:\
    * Open the file C:\apache-jmeter-2.13\bin\jmeter.properties, and find the following 3 entries and change the values like below
CookieManager.check.cookies=false
jmeter.save.saveservice.timestamp_format=yyyy/MM/dd HH:mm:ss.SSS
jmeter.save.saveservice.print_field_names=true
    * Open the file C:\apache-jmeter-2.13\bin\hc.parameters, and set http.connection.stalecheck$Boolean=false
    * Open the file C:\apache-jmeter-2.13\bin\user.properties, and add the following 2 lines
        * httpclient4.retrycount=1 
        * hc.parameters.file=hc.parameters
4. Download and configure 3rd party plugins
    * Download JMeterPlugins-Standard-1.3.1.zip from https://jmeter-plugins.org/downloads/old/, and extract the plugins to %JMeter_HOME%/lib/ext
    * Download ServerAgent-2.2.1.zip from https://jmeter-plugins.org/wiki/PerfMonAgent/, and extract to a folder, and then run startAgent.bat for Windows machines
5. Run C:\apache-jmeter-2.13\bin\jmeter.bat, you'll see the JMeter window
6. Open the attached jmeter script wordpress.1%write.jmx, and run
7. Unzip The WordPress Test Initialization and Reading&1%Writing Scripts To C:/ Disk