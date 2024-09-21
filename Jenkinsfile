pipeline {
    agent any

    stages {
        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                sh 'dotnet test --configuration Release --no-build'
            }
            post {
                always {
                    junit '**/TestResults/*.xml'
                }
            }
        }

        stage('Code Quality Analysis') {
            steps {
                withSonarQubeEnv('SonarQube') {
                    sh 'dotnet sonarscanner begin /k:"your-project-key"'
                    sh 'dotnet build'
                    sh 'dotnet sonarscanner end'
                }
            }
        }

        stage('Deploy') {
            steps {
                sh 'docker-compose up -d'
            }
        }

        stage('Monitoring') {
            steps {
                sh 'curl -X POST http://your-monitoring-tool/api/notify -d "Deployment completed."'
                sh 'echo "Monitoring setup completed."'
            }
        }
    }

    post {
        always {
            echo 'Pipeline completed.'
        }
    }
}
