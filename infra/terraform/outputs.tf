output "healthvision_bucket_name" {
  description = "Name of the HealthVision-CDS S3 bucket"
  value       = aws_s3_bucket.healthvision.bucket
}
