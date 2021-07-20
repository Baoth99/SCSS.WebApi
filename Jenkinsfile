pipeline {
    agent any

    tools {
        dotnetsdk 'asp.net5'
        git 'Default'
    }

    // withCredentials([[$class: 'UsernamePasswordMultiBinding', credentialsId: 'aws-key', usernameVariable: 'AWS_ACCESS_KEY_ID', passwordVariable: 'AWS_SECRET_ACCESS_KEY']]) {
    //     AWS("--region=eu-west-1 s3 ls")
    // }

    stages {
        stage('Clean Workspace') {
            steps {
              cleanWs()    
            }
        }
        stage('Git Checkout') {
            steps {
                git branch: 'develop_ci-cd', credentialsId: 'cc217be2-8270-4819-bc8e-0850c5358872', url: 'https://github.com/Baoth99/SCSS.WebApi.git'
            }
        }
        stage('Restore packages') {
            steps {
               bat 'dotnet restore "SCSS.WebApi\\SCSS.WebApi.csproj"'
            }
        }
        stage('Build') {
            steps {
               echo 'Build'    
               bat 'dotnet clean "SCSS.WebApi\\SCSS.WebApi.csproj"'               
               bat 'dotnet build "SCSS.WebApi\\SCSS.WebApi.csproj" -c Release -o /SCSS.WebApi/build'
            }
        }
        stage('Test') {
            steps {
                echo 'Test'    
            }
        }
        stage('Deploy') {
            steps {
                echo 'Deploy'  
                sh 'aws s3 ls'
                bat 'dotnet publish "SCSS.WebApi\\SCSS.WebApi.csproj" -c Release -o /SCSS.WebApi/publish'
            }
        }
    }
}