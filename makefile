run-test:
	make docker-test-up
	make test
	make docker-test-down

docker-test-up:
	docker-compose -f docker-compose.test.yml up --build -d

docker-test-down:
	docker-compose -f docker-compose.test.yml down

test:
	dotnet test