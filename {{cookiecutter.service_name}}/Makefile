build:
	docker build \
		-t "img_{{ cookiecutter.service_name }}:latest" \
		-f Dockerfile .

start: build
	docker run -it --rm --network=host \
		--name {{ cookiecutter.service_name }} \
		--user {{ cookiecutter.uid }} \
		"img_{{ cookiecutter.service_name }}:latest"
