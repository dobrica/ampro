#!/bin/bash
exec mongoimport --db=TextTemplates --collection=Templates --type=csv --headerline --file=/templates.csv
