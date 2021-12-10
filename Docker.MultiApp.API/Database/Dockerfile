FROM mcr.microsoft.com/mssql/server:2017-CU17-ubuntu


USER root

COPY Database_Setup.sql Database_Setup.sql
COPY import-data.sh import-data.sh
COPY entrypoint.sh entrypoint.sh

RUN chmod +x entrypoint.sh

CMD /bin/bash ./entrypoint.sh