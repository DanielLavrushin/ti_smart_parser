PROJECT=$1
python3 ../../dlrobot.py --clear-cache-folder --project $PROJECT 

files_count=`/usr/bin/find result -type f | grep -v json | wc -l`

if [ $files_count != 4 ]; then
    echo "4 files must be exported"
    exit 1
fi

