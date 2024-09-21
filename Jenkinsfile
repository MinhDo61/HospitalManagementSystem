pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Building the project...'
                sh 'mvn clean package'
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                sh 'mvn test'
            }
            post {
                always {
                    echo 'Archiving test results...'
                    junit '**/target/surefire-reports/*.xml'
                }
            }
        }

        stage('Code Quality Analysis') {
            steps {
                echo 'Running SonarQube analysis...'
                withSonarQubeEnv('SonarQube') {
                    sh 'mvn sonar:sonar'
                }
            }
        }

        stage('Deploy') {
            steps {
                echo 'Deploying to the test environment...'
                sh 'docker-compose up -d'
            }
        }

        stage('Release') {
            steps {
                echo 'Releasing to production...'
            }
        }
    }

    post {
        always {
            echo 'Pipeline finished. Sending notifications...'
        }
    }
}
