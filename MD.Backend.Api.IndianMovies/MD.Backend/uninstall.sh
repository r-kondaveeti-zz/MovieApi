#!/bin/bash

sfctl application delete --application-id MD.Backend
sfctl application unprovision --application-type-name MD.BackendType --application-type-version 1.0.0
sfctl store delete --content-path MD.Backend
