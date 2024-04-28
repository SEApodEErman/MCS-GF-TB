def milliseconds_to_srt_time(milliseconds):
    seconds = milliseconds // 1000
    milliseconds %= 1000
    minutes, seconds = divmod(seconds, 60)
    hours, minutes = divmod(minutes, 60)
    return "{:02d}:{:02d}:{:02d},{:03d}".format(hours, minutes, seconds, milliseconds)

# Read data from lyrics.txt with UTF-8 encoding
with open("lyrics.txt", "r", encoding="utf-8") as file:
    data = file.readlines()

# Convert and print to .srt format
for index, line in enumerate(data, start=1):
    time, lyric = line.split(' ', 1)
    start_time = milliseconds_to_srt_time(int(time))
    end_time = milliseconds_to_srt_time(int(data[index].split()[0])) if index < len(data) else "" # Assuming the next time is the end time
    print(f"{index}")
    print(f"{start_time} --> {end_time}")
    print(lyric.strip())
    print()
