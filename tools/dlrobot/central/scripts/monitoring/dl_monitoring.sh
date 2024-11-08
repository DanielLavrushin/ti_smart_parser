COMMON_SCRIPT=$(dirname $0)/../profile.sh
source $COMMON_SCRIPT
export TMP_FOLDER=/tmp/dlrobot_monitoring
export CENTRAL_STATS=$TOOLS/dlrobot/central/data/dlrobot_remote_calls.dat
export CONV_STATS=/home/sokirko/declarator_hdd/declarator/convert_stats.txt
CENTRAL_STATS_HISTORY=/tmp/dlrobot_central_stats_history.txt

python3 $TOOLS/ConvStorage/scripts/get_stats.py --history-file $CONV_STATS
curl $DLROBOT_CENTRAL_SERVER_ADDRESS/stats >>$CENTRAL_STATS_HISTORY

rm -rf $TMP_FOLDER;
mkdir $TMP_FOLDER;

python3 $TOOLS/dlrobot/central/scripts/monitoring/dl_monitoring.py --central-stats-file  $CENTRAL_STATS \
    --conversion-server-stats $CONV_STATS --central-server-cpu-and-mem  /tmp/glances.dat \
    --central-stats-history $CENTRAL_STATS_HISTORY --output-folder $TMP_FOLDER

scp $TMP_FOLDER/* $FRONTEND:$FRONTEND_DLROBOT_MONITORING_FOLDER

