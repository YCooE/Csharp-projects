#!/usr/bin/env bash

set -euo pipefail

dir="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

docker run \
  --interactive --tty --rm \
  --volume "${dir}/:/home/docker/src/" \
  --workdir "/home/docker/src/" \
  --entrypoint "/bin/ash" \
  dikunix/docker-gitlab-runner-mono:0.0.4
