import csv
import uuid
import random
from datetime import datetime, timedelta

# Function to generate a random GUID
def generate_guid():
    return str(uuid.uuid4())

# Function to generate a random datetime within a specific range
def generate_datetime(start_date, end_date):
    time_delta = end_date - start_date
    random_days = random.uniform(0, time_delta.days)
    random_time = timedelta(days=random_days)
    result_date = start_date + random_time
    return result_date.strftime("%Y-%m-%d %H:%M:%S")

# Function to generate a random percentage
def generate_percentage():
    return round(random.uniform(0, 100), 2)
def generate_vote():
    return round(random.uniform(1, 5))
def generate_AlarmConfig():
    return round(random.uniform(1,2))

# Specify the desired date range
start_date = datetime(2023, 10, 1)
end_date = datetime(2024, 5, 24)

# Generate 10,000 data records
data = []
for _ in range(200):
    camera_ids = [
        "68fdad3a-88e3-435a-b47a-d3359fb0fc6c",
        "f3532097-5d00-40b3-b38a-9d9659dd201d",
        "3f5f18af-0650-4dee-874a-989aa3a66d05"
    ]
    
    recommend_alarm = [
        'Alarm Level 1',
         'Alarm Level 2',
          'Alarm Level 3',
        'Alarm Level 4',
         'Alarm Level 5', 
    ]
    
    record = {
        'Id': generate_guid(),
        'RecordTime': generate_datetime(start_date, end_date),
        'Status': random.choice(['InFinish']),
        'PredictedPercent': generate_percentage(),
        'CameraID': random.choice(camera_ids),
        'RecordTypeID': 1,
        'CreatedDate': generate_datetime(start_date, end_date),
        'CreatedBy': "00000000-0000-0000-0000-000000000000",
        'FinishAlarmTime' : generate_datetime(start_date, end_date),
        'AlarmConfigurationId' : generate_AlarmConfig(),
        'RecommendAlarmLevel' : random.choice(recommend_alarm)
    }
    data.append(record)

# Specify the file path
filename = 'D:\\FACS\\FACS-Backend-API\\FireDetection.Grpc.System\\recordList.csv'

# Write to CSV file
with open(filename, 'w', newline='') as file:
    writer = csv.DictWriter(file, fieldnames=data[0].keys())
    writer.writeheader()
    writer.writerows(data)
