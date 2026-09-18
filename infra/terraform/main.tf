resource "aws_s3_bucket" "healthvision" {
  bucket_prefix = "healthvision-cds-"

  tags = {
    Project = "HealthVision-CDS"
    Managed = "Terraform"
  }
}
